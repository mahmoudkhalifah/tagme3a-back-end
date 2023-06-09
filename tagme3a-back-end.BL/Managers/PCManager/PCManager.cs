﻿using Microsoft.AspNetCore.Mvc;
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


            var result = pcs
            .Where(pc => pc.ProductsPC.Count() > 0)
            .Select(e => new PCReadDTO()
            {
                Id = e.PCId,
                BundleName = e.BundleName,
                Image = e.Image,
                TotalPrice = e.TotalPrice,
                products = e.ProductsPC.Select(p => new ProductReadInPCDTO()
                {
                    ProductId = p.Product.Id,
                    Name = p.Product?.Name ?? "",
                    Description = p.Product?.Description ?? "",
                    //BrandName = p.Product?.Brand?.Name ?? "",
                    //CategoryName = p.Product?.Category?.Name ?? "",
                    quantitiy = p.Quantity
                }).ToList()
            }).ToList();
            return result;
        }

        public IEnumerable<PCReadDTO> GetAllForAdmin()
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
                    ProductId = p.Product.Id,
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
                    ProductId = p.ProductId,
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
                decimal result = pc?.TotalPrice??0;
                result += (price * quantity);
                pc.TotalPrice = result;
                _pcRepo.UpdatePC(pc.PCId, pc);

        }

        public bool InsertPrdPC(PrdPCInsertDTO prdP)
        {
            var prdPc = _pcRepo.getAllPrdPc().Where(p=>p.PCId == prdP.PCId && p.ProductId == prdP.ProductId).FirstOrDefault(); 
            ProductPC Pc = new ProductPC()
            {
                ProductId = prdP.ProductId,
                PCId = prdP.PCId,
                Quantity = prdP.Quantity
            };
            var prd = _product.GetProductById(prdP.ProductId);

			//CalcPrice(prd.Price, prdP.Quantity - prdPc?.Quantity ?? 0, prdP.PCId);
			CalcPrice(prd.Price, prdP.Quantity, prdP.PCId);

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

		public bool UpdatePrdPC(int id, PrdPCUpdateDTO pc)
		{
            var curPC = _pcRepo.GetDetails(id);
            var prdPc = _pcRepo.getAllPrdPc().Where(p => p.PCId == id && p.ProductId == pc.ProductId).FirstOrDefault();
            ProductPC Pc = new ProductPC
            {
                Quantity = pc.Quantity,
                ProductId = pc.ProductId
            };
			var prd = _product.GetProductById(pc.ProductId);

            CalcPrice(prd.Price, pc.Quantity - prdPc.Quantity, id);
            return _pcRepo.UpdatePrdPC(id, Pc);
		}

		public void UpdatePrice(decimal price, int quantity, int pcId)
		{
			var pc = _pcRepo.GetDetails(pcId);
			decimal result = pc.TotalPrice;
			result -= (price * quantity);
			pc.TotalPrice = result;
			_pcRepo.UpdatePC(pc.PCId, pc);

		}

		public bool DeletePrdPC(int id, PrdPcDeleteDTO Prdpc)
		{
			var PrdToDel = _pcRepo.getAllPrdPc().Where(e=>e.PCId == id && e.ProductId== Prdpc.ProductId).FirstOrDefault();
			//var del = PrdToDel.ProductsPC.Select(e => e.ProductId == Prdpc.ProductId).FirstOrDefault();
			//ProductPC Pc = new ProductPC
			//{
			//	ProductId = Prdpc.ProductId
			//};
			var prd = _product.GetProductById(Prdpc.ProductId);


            UpdatePrice(prd.Price,PrdToDel.Quantity , id);

			return _pcRepo.DeletePrdPC(id, PrdToDel);
		}

		public IEnumerable<PrdPCInsertDTO> getAllPrdPc()
		{
            var prd = _pcRepo.getAllPrdPc();

			var res = prd.Select(p=> new PrdPCInsertDTO()
            {
                PCId = p.PCId,
                ProductId = p.ProductId,
                Quantity = p.Quantity,
            });

            return res;
        }
	}
}
