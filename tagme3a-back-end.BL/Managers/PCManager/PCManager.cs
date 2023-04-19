using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Category;
using tagme3a_back_end.BL.DTOs.PC;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers.PCManager
{
    public class PCManager : IPCManager
    {
        private readonly IPCsRepo _pcRepo;
        private readonly IProductRepo _product;

        public PCManager(IPCsRepo pcRepo , IProductRepo product)
        {
            this._pcRepo = pcRepo;
            this._product = product;
        }
        public IEnumerable<PCReadDTO> GetAll()
        {
            var pcs = _pcRepo.GetAll();
            if (pcs == null)
                return new List<PCReadDTO>();


            var result = pcs.Select(e => new PCReadDTO()
            {
                Id = e.PCId,
                BundleName = e.BundleName,
                Image = e.Image,
                TotalPrice = e.TotalPrice,
                products = e.ProductsPC.Select(p => new ProductReadInPCDTO()
                {
                    Name = p.Product?.Name ?? "",
                    Description = p.Product?.Description ?? "",
                    //BrandName = p.Product?.Brand?.Name ?? "",
                    //CategoryName = p.Product?.Category?.Name ?? "",
                    quantitiy = p.Quantity
                }).ToList()
            }).ToList();
            return result;
        }

        public PCReadDetailsDTO GetDetails(int id)
        {
            var pc = _pcRepo.GetDetails(id);
            if (pc == null)
                return new PCReadDetailsDTO();
            return new PCReadDetailsDTO()
            {
                Id = pc.PCId,
                BundleName = pc.BundleName,
                Image = pc.Image,
                TotalPrice = pc.TotalPrice,
                products = pc.ProductsPC.Select(p => new ProductReadDetailsInPCDTO
                {
                    Name = p.Product?.Name ?? "",
                    Description = p.Product?.Description ?? "",
                    price = p.Product?.Price ?? 0,
                    //Img = p.Product.ProductImages,
                    BrandName = p.Product?.Brand?.Name ?? "",
                    CategoryName = p.Product?.Category?.Name ?? "",
                    Image = p.Product?.ProductImages.Select(i => i.Photo).FirstOrDefault(),
                    quantitiy = p.Quantity,

                }).ToList()
            };
        }

        public bool InsertPC(PCInsertDTO pc)
        {
            byte[] imageBytes = Convert.FromBase64String(pc.Image);

            PC Pc = new PC()
            {
                BundleName = pc.BundleName,
                Image = imageBytes

            };
            return _pcRepo.InsertPC(Pc);
        }

        public void CalcPrice(decimal price , int quantity,int pcId)
        {
            var pc = _pcRepo.GetDetails(pcId);
                decimal result = pc.TotalPrice;
                result += (price * quantity);
                pc.TotalPrice = result;
                _pcRepo.UpdatePC(pc.PCId, pc);

        }

        public bool InsertPrdPC(PrdPCInsertDTO prdP)
        {

            ProductPC Pc = new ProductPC()
            {
                ProductId = prdP.ProductId,
                PCId = prdP.PCId,
                Quantity = prdP.Quantity
            };
            var prd = _product.GetProductById(prdP.ProductId);
            CalcPrice(prd.Price,prdP.Quantity, prdP.PCId);

            return _pcRepo.InsertPrdPC(Pc);
        }

        public bool DeletePC(int id)
        {
            return _pcRepo.DeletePC(id);
        }

        public bool UpdatePC(int id, PCInsertDTO pc)
        {
            var Pc = _pcRepo.GetDetails(id);
            if (Pc == null)
                return false;

            Pc.BundleName = pc.BundleName;
            Pc.TotalPrice = pc.TotalPrice;
            byte[] data = Convert.FromBase64String(pc.Image);

            Pc.Image = data;

            return _pcRepo.UpdatePC(id, Pc);
        }

    }
}
