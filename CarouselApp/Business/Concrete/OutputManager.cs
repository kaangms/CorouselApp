using Core.Utilities.Results;
using CorouselApp.Busines.Abstract;
using CorouselApp.Business.Concrete;
using CorouselApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorouselApp.Busines.Concrete
{
    public class OutputManager : IOutputService
    {
        public int unitPrice = 1;


        public IDataResult<int> MathInputData()
        {
            var inputManager = new InputManager();
            var carouselDto = inputManager.AddCarouselDto().Data;
            var carousel = carouselDto.Carousel;
            var riderGroups = inputManager.AddRiderGroup(carouselDto).Data.ToList().OrderBy(r => r.RowNumber);
            int gain=0; 

            for (int i = 0; i < carousel.WorkingAmount; i++)
            {               
                CheckRidersGroup(carousel.SeatTotal, riderGroups);
                var groupRoundRiders = riderGroups.Where(r => r.IsRider == true);
                foreach (var item in groupRoundRiders)
                {
                    gain += item.RiderAmount * unitPrice;
                    item.IsRider = false;

                }

                Console.WriteLine(gain);
            }

            return new SuccessDataResult<int>(gain);
        }

        private void CheckRidersGroup(int seatTotal,  IEnumerable<RiderGroup> riderGroups)
        {
            var checkSeat = seatTotal;
            foreach (var riderGroup in riderGroups)
            {
               

                seatTotal -= riderGroup.RiderAmount;

                if (seatTotal>=0)
                {
                    riderGroup.IsRider = true;
                    riderGroup.RowNumber+=riderGroups.Count();
                }
               
               
            }
            
        }
    }
}
