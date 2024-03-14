using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
    {
        //Business Rules

        //Mapping ---> automapper  
        //Gelen requesti veritabanı nesnesine çevirdik
        Brand brand = new Brand();
        brand.Name = createBrandRequest.Name;
        brand.CreatedDate = DateTime.Now;

        //veritabanına ekledik
        _brandDal.Add(brand);

        //veritabanından geleni de responseye çevirip 
        CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
        createdBrandResponse.Name = brand.Name;
        createdBrandResponse.Id = 4;
        createdBrandResponse.CreatedDate = brand.CreatedDate;

        //returnledik.
        return createdBrandResponse;
    }

    public List<GetAllBrandResponse> GetAll()
    {
        throw new NotImplementedException();
    }
}
