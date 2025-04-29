using FlashCardApi.Models;
using FlashCardApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardApi.Controllers
{
    [ApiController]
    [Route("flashcard")]
    public class FlashCardController : ControllerBase
    {
        private readonly IFlashDeckService _flashDeckService;

        public FlashCardController(IFlashDeckService flashDeckService)
        {
            _flashDeckService = flashDeckService;
        }

        [HttpGet("current")]
        public ActionResult<FlashCard> GetCurrentCard()
        {
            try
            {
                var card = _flashDeckService.GetCurrentCard();
                return Ok(card);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("flip")]
        public IActionResult FlipCurrentCard()
        {
            try
            {
                _flashDeckService.FlipCurrentCard();
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("submit")]
        public IActionResult SubmitAnswer([FromQuery] bool correct)
        {
            _flashDeckService.SubmitAnswer(correct);
            return NoContent();
        }

        [HttpPost("next")]
        public IActionResult MoveToNextCard()
        {
            _flashDeckService.MoveToNextCard();
            return NoContent();
        }

        [HttpGet("empty")]
        public ActionResult<bool> IsDeckEmpty()
        {
            return Ok(_flashDeckService.IsDeckEmpty());
        }
    }
}
