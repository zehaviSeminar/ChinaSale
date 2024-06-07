using Project.Models.DTO;
using AutoMapper;
using System.Collections.Generic;
using Project.DAL;
namespace Project.Models;

public class ProFile : Profile
{
    public ProFile()
    {
        CreateMap<DonorsDTO, Donors>();
        CreateMap<Donors, DonorsDTO>();

        CreateMap<PresentDTO, Presents>();
        CreateMap<Presents, PresentDTO>();

        CreateMap<PresentDTO2, Presents>();
        CreateMap<Presents, PresentDTO2>();

        CreateMap<BuyerDTO, Buyer>();
        CreateMap<Buyer, BuyerDTO>();

        CreateMap<CardDTO, Card>();
        CreateMap<Card, CardDTO>();


        CreateMap<PurchasesDTO, Purchases>();
        CreateMap<Purchases, PurchasesDTO>();


    }


}
