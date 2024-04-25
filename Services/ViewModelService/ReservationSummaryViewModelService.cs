using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services.ViewModelService
{
    public class ReservationSummaryViewModelService
    {
        private readonly IMapper _mapper;

        public ReservationSummaryViewModelService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ReservationSummaryViewModel CreateReservationSummaryViewModel(Reservation reservation)
        {
            return _mapper.Map<ReservationSummaryViewModel>(reservation);
        }
    }
}
