﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class GrupoUsuario
    {
        public string Descricao { get; set; }
        public List<Permissao> Permissoes { get; set; }
    }
}
