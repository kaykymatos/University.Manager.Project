using AutoMapper;
using University.Manager.Project.Order.Application.DTOs;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;
using University.Manager.Project.Order.Application.Interfaces;
using University.Manager.Project.Order.Domain.Entities;
using University.Manager.Project.Order.Domain.Interfaces;

namespace University.Manager.Project.Order.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task CreateModelAsync(OrderEntityRequestDTO entity)
        {
            var model = _mapper.Map<OrderEntity>(entity);

            var createModel = await _orderRepository.CreateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on create a new Order");
        }

        public async Task DeleteModelAsync(OrderEntityDTO entity)
        {
            var model = _mapper.Map<OrderEntity>(entity);

            var deleteModel = await _orderRepository.DeleteModelAsync(model);
            if (deleteModel == null)
                throw new ApplicationException("Error on delete a Order");
        }

        public async Task<IEnumerable<OrderEntityDTO>> GetAllAsync()
        {
            var listOrders = await _orderRepository.GetAllAsync();
            return listOrders == null ?
                throw new ApplicationException("Error on list a Orders")
                : _mapper.Map<IEnumerable<OrderEntityDTO>>(listOrders);
        }

        public async Task<OrderEntityDTO> GetByIdAsync(long id)
        {
            var model = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderEntityDTO>(model);
        }
        public async Task UpdateModelAsync(OrderEntityRequestDTO entity)
        {
            var model = _mapper.Map<OrderEntity>(entity);

            var createModel = await _orderRepository.UpdateModelAsync(model);
            if (createModel == null)
                throw new ApplicationException("Error on delete a Order");

        }
    }
}
