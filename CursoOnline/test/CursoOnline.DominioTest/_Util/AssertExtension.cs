﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CursoOnline.DominioTest._Util
{
    //Metodos de extensãod evem ser sempre estaticos!
    public static class AssertExtension
    {
        public static void ComMensagem(this ArgumentException exception, string mensagem)
        {
            if(exception.Message == mensagem)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
            }
        }
    }
}
