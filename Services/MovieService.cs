﻿using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface IMovieService
    {
        void AddMovies(Movie movie);
        void DeleteMovies(Movie movie);
        Movie FindBy(int id);
        List<Movie> FindBy(string searchString);
        Episode FindEpisode(int episodeId);
        List<Movie> FindNewestMovie(int take);
        List<Movie> FindPopularMovie(int take);
        List<Movie> ToList();
    }

    public class MovieService : IMovieService
    {
        private readonly NeptuneContext _context;

        public MovieService(NeptuneContext context)
        {
            _context = context;
        }

        public List<Movie> ToList()
        {
            return _context.Movies
                .Include(x => x.GenreMovies)
                .OrderBy(x => x.Name)
                .ToList();
        }

        public Movie FindBy(int id)
        {
            return _context.Movies
                .Include(x => x.GenreMovies)
                .ThenInclude(x => x.Genre)
                .Include(x => x.Episodes)
                .SingleOrDefault(x => x.Id == id);
        }

        public List<Movie> FindBy(string searchString)
        {
            return _context.Movies
                .Where(x => x.Name.Contains(searchString))
                .Include(x => x.GenreMovies)
                .OrderBy(x => x.Name)
                .ToList();
        }

        public List<Movie> FindNewestMovie(int take)
        {
            return _context.Movies
                .OrderByDescending(x => x.Release)
                .Take(take)
                .ToList();
        }

        public List<Movie> FindPopularMovie(int take)
        {
            return _context.Movies
                .OrderByDescending(x => x.Views)
                .Take(take)
                .ToList();
        }

        public void AddMovies(Movie movie)
        {
            movie.GenreMovies.ToList().ForEach(x => _context.Genres.Attach(x.Genre));
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void DeleteMovies(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public Episode FindEpisode(int episodeId)
        {
            return _context.Episodes.Find(episodeId);
        }
    }
}