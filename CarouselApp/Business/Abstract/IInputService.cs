using Core.Utilities.Results;
using CorouselApp.Entities;
using System.Collections.Generic;

namespace CorouselApp.Business.Abstract
{
    public interface IInputService
    {
       IDataResult<CarouselDto> AddCarouselDto();
       IDataResult<List<RiderGroup>> AddRiderGroup(CarouselDto carouselDto);
    }
}
