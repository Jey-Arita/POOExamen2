﻿using Examen2.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen2.Dtos.Clientes
{
    public class ClienteDto
    {
        public Guid IdCliente { get; set; }
    }
}
