using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class PaisController : BaseApiController
    {
        public readonly IPaisInterface? _paisRepositoy;
        private readonly IMapper _mapper;

        public PaisController(IPaisInterface paisRepository, IMapper mapper)
        {
            _paisRepositoy = paisRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PaisesDto>>> Get()
        {
            var paises = await _paisRepositoy.GetAllAsync();
            return _mapper.Map<List<PaisesDto>>(paises);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PaisesDto>> Get(int id)
        {
            var paises = await _paisRepositoy.GetByIdAsync(id);
            return _mapper.Map<PaisesDto>(paises);
        }

    }
