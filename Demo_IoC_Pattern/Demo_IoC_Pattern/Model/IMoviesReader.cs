﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_IoC_Pattern.Model
{
    public interface IMoviesReader
    {
        List<Movie> ReadMovies();
    }
}
