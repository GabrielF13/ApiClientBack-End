using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {

                return BadRequest("Request Invalid");
            }
        }

        [HttpGet("AlunoByName")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunoByName([FromQuery] string name)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(name);
                if (alunos.Count()==0)
                    return NotFound("Nenhum aluno encontrado com esse nome!");
                return Ok(alunos);
            }
            catch
            {

                return BadRequest("Request Invalid");
            }
        }

        [HttpGet("{id:int}", Name = "GetAluno")]

        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno == null)
                    return NotFound($"Não existe aluno com esse id: {id}");

                return Ok(aluno);
            }
            catch
            {

                return BadRequest("Request Invalid");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);

                return Ok();
            }
            catch
            {

                return BadRequest("Request Invalid");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit (int id,[FromBody] Aluno aluno)
        {
            try
            {
                if (aluno.Id == id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"Aluno com com id{id}, atualizado com sucesso");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {

                return BadRequest("Request Invalid");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno ==null)
                {
                    return NotFound("Aluno Não encontrado");
                }

                await _alunoService.DeleteAluno(aluno);
                return Ok();
            }
            catch
            {

                return BadRequest("Request Invalid");
            }
        }
    }
}