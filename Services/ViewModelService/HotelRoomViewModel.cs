using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services.ViewModelService
{
    public class HotelRoomViewModel
    {
        private readonly IMapper _mapper;
        public HotelRoomViewModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        public HotelRoomViewModel CreateHotelRoomViewModel(HotelRoom rooms)
        {
            return _mapper.Map<HotelRoomViewModel>(rooms);
        }
    }
}
