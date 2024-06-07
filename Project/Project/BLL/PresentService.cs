﻿using AutoMapper;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.BLL;
public class PresentService : IPresentService
{
    private readonly IPresentDal presentDal;
    private readonly IMapper _mapper;


    public PresentService(IPresentDal presentDal, IMapper mapper)
    {
        this.presentDal = presentDal;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PresentDTO2>> Get()
    {
        IEnumerable<Presents> p =await presentDal.Get();
        var pp = _mapper.Map<IEnumerable<PresentDTO2>>(p);
        return pp;
    }
    public Presents AddPresents(PresentDTO p)
    {
        var pr = _mapper.Map<Presents>(p);

        return presentDal.AddPresents(pr);
    }
    public void RemoveById(int id)
    {
        presentDal.RemoveById(id);
    }
    public PresentDTO UpdateP(int id, PresentDTO pre)
    {
        var p = _mapper.Map<Presents>(pre);
        var pres = _mapper.Map<PresentDTO>(presentDal.UpdateP(id, p));
        return pres;
    }
    public async Task<IEnumerable<Presents>> GetPresentByBuyer(int IdBuyer)
    {
        return await presentDal.GetPresentByBuyer(IdBuyer);
    }
  //  public IEnumerable<Presents> GetPresentByDonor(int DonorId)
   // {
  //      return presentDal.GetPresentByDonor(DonorId);
   // }
    public async Task<IEnumerable<Presents>> GetPresentByNumOfPurchasers(int NumOfPurchasers)
    {
        return await presentDal.GetPresentByNumOfPurchasers(NumOfPurchasers);
    }


    public async Task<IEnumerable<PresentDTO2>> getPresentsPurcheses(int buyerId)
    {
        IEnumerable<Presents> p = await presentDal.getPresentsPurcheses(buyerId);
        var pp = _mapper.Map<IEnumerable<PresentDTO2>>(p);
        return pp;
    }
    public void RemoveSeveralPresent(List<PresentDTO2> presents)
    {
        presentDal.RemoveSeveralPresent(presents);
    }


}

