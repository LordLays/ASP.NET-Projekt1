using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services.ViewModelService
{
    public class HotelOffertViewModelService
    {
        private readonly IMapper _mapper;
        public HotelOffertViewModelService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public HotelOffertViewModel CreateHotelOfferViewModel(Offert offert)
        {
            return _mapper.Map<HotelOffertViewModel>(offert);
        }

    }
}
