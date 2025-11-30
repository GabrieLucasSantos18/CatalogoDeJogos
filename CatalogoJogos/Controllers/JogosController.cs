using CatalogoJogos.Data;
using CatalogoJogos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoJogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly CatalogoJogosContext _context;

        public JogosController(CatalogoJogosContext context)
        {
            _context = context;
        }

        // GET: api/Jogos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogo>>> GetJogos()
        {
            return await _context.Jogos
                .Include(j => j.Jogopcs)
                .Include(j => j.Jogoconsoles)
                .Include(j => j.Jogomobiles)
                .ToListAsync();
        }

        // GET: api/Jogos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jogo>> GetJogo(int id)
        {
            var jogo = await _context.Jogos
                .Include(j => j.Jogopcs)
                .Include(j => j.Jogoconsoles)
                .Include(j => j.Jogomobiles)
                .FirstOrDefaultAsync(j => j.IdJogo == id);

            if (jogo == null) return NotFound("Jogo não encontrado.");

            return jogo;
        }

        // POST: api/Jogos/PC
        [HttpPost("PC")]
        public async Task<ActionResult> PostJogoPC(JogoPCDTO dto)
        {
            var novoJogo = HelperCriarJogoBase(dto, "PC");
            _context.Jogos.Add(novoJogo);
            await _context.SaveChangesAsync();

            var jogoPc = new Jogopc
            {
                IdJogo = novoJogo.IdJogo,
                RequisitosMinimos = dto.RequisitosMinimos,
                RequisitosRecomendados = dto.RequisitosRecomendados
            };
            _context.Jogopcs.Add(jogoPc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogo", new { id = novoJogo.IdJogo }, novoJogo);
        }

        // POST: api/Jogos/Console
        [HttpPost("Console")]
        public async Task<ActionResult> PostJogoConsole(JogoConsoleDTO dto)
        {
            var novoJogo = HelperCriarJogoBase(dto, "Console");
            _context.Jogos.Add(novoJogo);
            await _context.SaveChangesAsync();

            var jogoConsole = new Jogoconsole
            {
                IdJogo = novoJogo.IdJogo,
                ConsoleEspecifico = dto.ConsoleEspecifico,
                // CORREÇÃO AQUI: Atribuição direta, sem converter para sbyte
                SuporteMultiplayer = dto.SuporteMultiplayer
            };
            _context.Jogoconsoles.Add(jogoConsole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogo", new { id = novoJogo.IdJogo }, novoJogo);
        }

        // POST: api/Jogos/Mobile
        [HttpPost("Mobile")]
        public async Task<ActionResult> PostJogoMobile(JogoMobileDTO dto)
        {
            var novoJogo = HelperCriarJogoBase(dto, "Mobile");
            _context.Jogos.Add(novoJogo);
            await _context.SaveChangesAsync();

            var jogoMobile = new Jogomobile
            {
                IdJogo = novoJogo.IdJogo,
                // CORREÇÃO AQUI: Atribuição direta
                PrecisaConexao = dto.PrecisaConexao
            };
            _context.Jogomobiles.Add(jogoMobile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogo", new { id = novoJogo.IdJogo }, novoJogo);
        }

        // PUT: api/Jogos/PC/5
        [HttpPut("PC/{id}")]
        public async Task<IActionResult> PutJogoPC(int id, JogoPCDTO dto)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null) return NotFound("Jogo base não encontrado.");

            var jogoPc = await _context.Jogopcs.FirstOrDefaultAsync(x => x.IdJogo == id);
            if (jogoPc == null) return NotFound("Detalhes de PC não encontrados.");

            HelperAtualizarJogoBase(jogo, dto);

            jogoPc.RequisitosMinimos = dto.RequisitosMinimos;
            jogoPc.RequisitosRecomendados = dto.RequisitosRecomendados;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/Jogos/Console/5
        [HttpPut("Console/{id}")]
        public async Task<IActionResult> PutJogoConsole(int id, JogoConsoleDTO dto)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null) return NotFound();

            var jogoConsole = await _context.Jogoconsoles.FirstOrDefaultAsync(x => x.IdJogo == id);
            if (jogoConsole == null) return NotFound("Detalhes de Console não encontrados.");

            HelperAtualizarJogoBase(jogo, dto);

            jogoConsole.ConsoleEspecifico = dto.ConsoleEspecifico;
            // CORREÇÃO AQUI: Direto bool para bool
            jogoConsole.SuporteMultiplayer = dto.SuporteMultiplayer;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/Jogos/Mobile/5
        [HttpPut("Mobile/{id}")]
        public async Task<IActionResult> PutJogoMobile(int id, JogoMobileDTO dto)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null) return NotFound();

            var jogoMobile = await _context.Jogomobiles.FirstOrDefaultAsync(x => x.IdJogo == id);
            if (jogoMobile == null) return NotFound("Detalhes Mobile não encontrados.");

            HelperAtualizarJogoBase(jogo, dto);

            // CORREÇÃO AQUI: Direto bool para bool
            jogoMobile.PrecisaConexao = dto.PrecisaConexao;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Jogos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null) return NotFound("Jogo não encontrado.");

            var pc = await _context.Jogopcs.FirstOrDefaultAsync(x => x.IdJogo == id);
            if (pc != null) _context.Jogopcs.Remove(pc);

            var console = await _context.Jogoconsoles.FirstOrDefaultAsync(x => x.IdJogo == id);
            if (console != null) _context.Jogoconsoles.Remove(console);

            var mobile = await _context.Jogomobiles.FirstOrDefaultAsync(x => x.IdJogo == id);
            if (mobile != null) _context.Jogomobiles.Remove(mobile);

            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // --- HELPERS ---
        private Jogo HelperCriarJogoBase(JogoBaseDTO dto, string plataforma)
        {
            return new Jogo
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Genero = dto.Genero,
                Preco = dto.Preco,
                Tamanho = dto.Tamanho,
                // O cast para sbyte aqui continua, pois Classificacao é número, não bool
                Classificacao = (sbyte)dto.Classificacao,
                Avaliacao = dto.Avaliacao,
                Desenvolvedora = dto.Desenvolvedora,
                Plataforma = plataforma,
                DataLancamento = DateTime.Now
            };
        }

        private void HelperAtualizarJogoBase(Jogo jogo, JogoBaseDTO dto)
        {
            jogo.Titulo = dto.Titulo;
            jogo.Descricao = dto.Descricao;
            jogo.Genero = dto.Genero;
            jogo.Preco = dto.Preco;
            jogo.Tamanho = dto.Tamanho;
            jogo.Classificacao = (sbyte)dto.Classificacao;
            jogo.Avaliacao = dto.Avaliacao;
            jogo.Desenvolvedora = dto.Desenvolvedora;
        }
    }

    // --- DTOs ---
    public class JogoBaseDTO
    {
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public decimal Preco { get; set; }
        public long Tamanho { get; set; }
        public int Classificacao { get; set; }
        public string Avaliacao { get; set; } = null!;
        public string Desenvolvedora { get; set; } = null!;
    }

    public class JogoPCDTO : JogoBaseDTO
    {
        public string RequisitosMinimos { get; set; } = null!;
        public string RequisitosRecomendados { get; set; } = null!;
    }

    public class JogoConsoleDTO : JogoBaseDTO
    {
        public string ConsoleEspecifico { get; set; } = null!;
        public bool SuporteMultiplayer { get; set; }
    }

    public class JogoMobileDTO : JogoBaseDTO
    {
        public bool PrecisaConexao { get; set; }
    }
}