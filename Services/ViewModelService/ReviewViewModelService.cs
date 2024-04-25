using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services.ViewModelService
{
    public class ReviewViewModelService
    {
        private readonly IMapper _mapper;

        public ReviewViewModelService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ReviewViewModelService CreateReservationSummaryViewModel(Review review)
        {
            return _mapper.Map<ReviewViewModelService>(review);
        }
    }
}
