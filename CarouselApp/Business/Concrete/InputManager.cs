using Core.Utilities.Results;
using CorouselApp.Busines.Constants;
using CorouselApp.Business.Abstract;
using CorouselApp.Core.Utilities.Business;
using CorouselApp.Entities;
using System;
using System.Collections.Generic;

namespace CorouselApp.Business.Concrete
{
    public class InputManager : IInputService
    {
        public IDataResult<CarouselDto> AddCarouselDto()
        {

            var checkEntryData = true;

            while (checkEntryData)
            {
                var enterCarouselDto = EnterCarouselDto();
                checkEntryData = !enterCarouselDto.Success;
                //enterCarouselDto.Success true olduğu zaman çıkması için false çektik
                if (!checkEntryData)
                {
                    var carouselDto = new CarouselDto
                    {
                        Carousel = new Carousel
                        {
                            WorkingAmount = Convert.ToInt32(enterCarouselDto.Data[0]),
                            SeatTotal = Convert.ToInt32(enterCarouselDto.Data[1])
                        },
                        RiderGropAmount = Convert.ToInt32(enterCarouselDto.Data[2]),

                    };

                    return new SuccessDataResult<CarouselDto>(carouselDto);
                }
            }
            return new ErrorDataResult<CarouselDto>();

        }
        private IDataResult<string[]> EnterCarouselDto()
        {
            var caruselDto = EnterDataRequset(Messages.EnterCarouselDtoRequset);
            var result = BusinessRules.Run(
                CheckIfDataCount(caruselDto.Length),
                CheckIfDataTypes(caruselDto));

            if (result != null)
            {//burası hatalı
                return new ErrorDataResult<string[]>();
            }

            return new SuccessDataResult<string[]>(caruselDto);
        }

      
        private string[] EnterDataRequset(string messages)
        {

            Console.WriteLine(messages);
            var enterData = Console.ReadLine();
            return enterData.Split(' ');
        }

        public IDataResult<List<RiderGroup>> AddRiderGroup(CarouselDto carouselDto)
        {
            List<RiderGroup> riderGroups = new List<RiderGroup>();
            var checkEntryData = true;

            while (checkEntryData)
            {

                var enterRiderGroup = EnterRiderGroup(carouselDto.RiderGropAmount);
                checkEntryData = !enterRiderGroup.Success;
                ///enterCarouselDto.Success true olduğu zaman çıkması için false çektik
                if (!checkEntryData)
                {

                    for (int i = 0; i < enterRiderGroup.Data.Length; i++)
                    {
                        var riderGroup = new RiderGroup
                        {
                            RowNumber = i + 1,
                            RiderAmount = Convert.ToInt32(enterRiderGroup.Data[i])

                        };

                        riderGroups.Add(riderGroup);
                    }


                    return new SuccessDataResult<List<RiderGroup>>(riderGroups);
                }
            }
            return new ErrorDataResult<List<RiderGroup>>();

        }
        private IDataResult<string[]> EnterRiderGroup(int riderGroupAmount)
        {

            var riderGroup = EnterDataRequset(Messages.EnterRiderGroupRequset);
            var result = BusinessRules.Run(
                CheckIfDataCount(riderGroup.Length, riderGroupAmount),
                CheckIfDataTypes(riderGroup),
                CheckSeatForGroupRiderAmount(riderGroup[1], riderGroup));

            if (result != null)
            {//burası hatalı
                return new ErrorDataResult<string[]>();
            }

            return new SuccessDataResult<string[]>(riderGroup);
        }



        private IResult CheckIfDataCount(int length, int maxRange = 3) => length == maxRange
          ? new SuccessResult()
          : new ErrorResult(Messages.ErrorEntry);
        private IResult CheckIfDataTypes(string[] items)
        {
            foreach (var item in items)
            {
                try
                {
                    var newItem = Convert.ToInt32(item);
                    if (newItem < 1)
                    {
                        return new ErrorResult(Messages.ErrorEntry);
                    }
                }
                catch (Exception)
                {
                    return new ErrorResult(Messages.ErrorEntry);

                }
            }
            return new SuccessResult();
        }


        private IResult CheckSeatForGroupRiderAmount(string seatAmount, string[] items)
        {
            foreach (var item in items)
            {
                int seatControl, groupAmountControl;
                int.TryParse(seatAmount, out seatControl);
                int.TryParse(item, out groupAmountControl);
                return seatControl < groupAmountControl
                    ? new ErrorResult(Messages.GroupNumberIsMuchesSeats)
                    : new SuccessResult(); ;
            }
            return new SuccessResult();

        }
    }
}
