﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.DTOs
{
    public class CustomerDTO
    {
        public int cliente_id { get; set; }

        public string numero_identificacion { get; set; }


        public string tipo_identificacion { get; set; }


        public string primer_nombre { get; set; }


        public string segundo_nombre { get; set; }


        public string primer_apellido { get; set; }


        public string segundo_apellido { get; set; }

        public string direccion { get; set; }
        public int direccion_id { get; set; }

        public bool? estado { get; set; }
    }
}