using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Создание нового заказа
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderId = await _orderService.CreateOrderAsync(dto);
            return CreatedAtAction(nameof(GetById), new { orderId }, orderId);
        }

        /// <summary>
        /// Получить все заказы текущего пользователя
        /// </summary>
        [HttpGet("my")]
        public async Task<IActionResult> GetMyOrders()
        {
            var userId = GetUserId();
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        /// <summary>
        /// Получить заказ по ID
        /// </summary>
        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetById(Guid orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        /// <summary>
        /// Обновить статус заказа
        /// </summary>
        [HttpPut("{orderId:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid orderId, [FromQuery] OrderStatus status)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, status);
            return NoContent();
        }

        /// <summary>
        /// Отменить заказ
        /// </summary>
        [HttpDelete("{orderId:guid}")]
        public async Task<IActionResult> CancelOrder(Guid orderId)
        {
            await _orderService.CancelOrderAsync(orderId);
            return NoContent();
        }

        // Вспомогательный метод для извлечения UserId из Claims
        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
                throw new UnauthorizedAccessException("User ID is missing or invalid in claims.");

            return userId;
        }
    }
}
