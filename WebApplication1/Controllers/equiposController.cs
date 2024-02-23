﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {

        private readonly equiposContext _equiposContexto;


        public equiposController(equiposContext equiposContexto)
        {
            _equiposContexto = equiposContexto;


        }

        /// <summary>
        /// EndPoint que retorna el lisado de todos los equipos existentes 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<equipos> listadoEquipo = (from e in _equiposContexto.equipos
                                           select e).ToList();

            if (listadoEquipo.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoEquipo);
        }





        /// <summary>
        /// EndPoint que retorna el lisado de todos los equipos existentes 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            equipos? equipo = (from e in _equiposContexto.equipos
                                           where e.id_equipos == id
                                           select e).FirstOrDefault();

            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }



    }


}
