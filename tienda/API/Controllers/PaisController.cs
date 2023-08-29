using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class PaisController : BaseApiController
    {
        public readonly IPaisInterface? _paisRepositoy;

        public PaisController(IPaisInterface paisRepository)
        {
            _paisRepositoy = paisRepository;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Pais>>> Get()
        {
            var paises = await _paisRepositoy.GetAllAsync();
            return Ok(paises);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var paises = await _paisRepositoy.GetByIdAsync(id);
            return Ok(paises);
        }

    }
