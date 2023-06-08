using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Models.Common;
using MovieLibrary.Core.Models.Movies;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using MovieLibrary.Data.Repositories.Movies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieBaseRepository;
        private readonly IRepository<MovieCategory> _movieCategoryBaseRepository;
        private readonly IMovieRepository _movieRepository;

        public MovieService(IRepository<Movie> repository,
            IMovieRepository movieBaseRepository,
            IRepository<MovieCategory> movieCategoryBaseRepository)
        {
            _movieBaseRepository = repository;
            _movieRepository = movieBaseRepository;
            _movieCategoryBaseRepository = movieCategoryBaseRepository;
        }


        public async Task<MovieGet> Get(int id)
        {
            var movieDto = await _movieRepository.Get(id);

            return movieDto != null ? new MovieGet(movieDto) : null;
        }


        public async Task<SearchResult<MovieItem>> Filter(MovieFilter criteria)
        {
            var moviesQuery = await _movieRepository.GetList();

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                moviesQuery = moviesQuery.Where(m => m.Title.ToLower().Contains(criteria.Name.ToLower()));
            }

            if (criteria.CategoryIds != null && criteria.CategoryIds.Any())
            {
                moviesQuery = moviesQuery.Where(m => m.MovieCategories.Any(mc => criteria.CategoryIds.Contains(mc.CategoryId)));
            }

            if (criteria.MinImdb.HasValue)
            {
                moviesQuery = moviesQuery.Where(m => m.ImdbRating >= criteria.MinImdb);
            }

            if (criteria.MaxImdb.HasValue)
            {
                moviesQuery = moviesQuery.Where(m => m.ImdbRating <= criteria.MaxImdb);
            }

            moviesQuery.OrderByDescending(m => m.ImdbRating);

            var totalRows = await moviesQuery.CountAsync();
            var moviesDto = await moviesQuery.Skip((criteria.PageNumber - 1) * criteria.PageSize).Take(criteria.PageSize).ToListAsync();

            var movies = moviesDto.Select(m => new MovieItem(m));

            var searchResult = new SearchResult<MovieItem>
            {
                TotalRows = totalRows,
                Items = movies
            };


            return searchResult;
        }


        public async Task Update(int id, MovieUpdate movie)
        {
            var movieDto = await _movieRepository.Get(id);

            await _movieBaseRepository.Update(movie.ToMovieDto(id));


            if (movieDto.MovieCategories != null && movieDto.MovieCategories.Any())
            {
                foreach (var movieCategory in movieDto.MovieCategories)
                {
                    if (!movie.CategoryIds.Contains(movieCategory.CategoryId))
                    {
                        await _movieCategoryBaseRepository.Delete(movieCategory.Id);
                    }
                }
            }

            if (movie.CategoryIds != null && movie.CategoryIds.Any())
            {

                foreach (var categoryId in movie.CategoryIds)
                {
                    if (!movieDto.MovieCategories.Select(x => x.CategoryId).Contains(categoryId))
                    {
                        await _movieCategoryBaseRepository.Create(new MovieCategory() { CategoryId = categoryId, MovieId = id });
                    }
                }
            }
        }

        public async Task<int> Create(MovieCreate movie)
        {
            int id = await _movieBaseRepository.Create(movie.ToMovieDto());

            if (movie.CategoryIds != null && movie.CategoryIds.Any())
            {

                foreach (var categoryId in movie.CategoryIds)
                {
                    await _movieCategoryBaseRepository.Create(new MovieCategory() { MovieId = id, CategoryId = categoryId });
                }
            }

            return id;
        }

        public async Task<bool> Delete(int id)
        {
            var movieDto = await _movieRepository.Get(id);

            bool isSucces = await _movieBaseRepository.Delete(id);

            if (movieDto.MovieCategories != null && movieDto.MovieCategories.Any())
            {
                foreach (var movieCategory in movieDto.MovieCategories)
                {
                    await _movieCategoryBaseRepository.Delete(movieCategory.Id);
                }
            }

            return isSucces;
        }

    }
}
