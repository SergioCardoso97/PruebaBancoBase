﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_DTO.DAO.Productos
{
    public class ActualizarProducto
    {
        public int Id { get; set; }
        public int IdVendedor { get; set; }
        public string Producto { get; set; }
        public double Precio { get; set; }
    }
}
