﻿using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecessaryDrugs.Core.Services
{
    public class OrderService : IOrderService
    {
        private IMedicineStoreUnitOfWork _medicineStoreUnitOfWork;
        public OrderService(IMedicineStoreUnitOfWork medicineStoreUnitOfWork)
        {
            _medicineStoreUnitOfWork = medicineStoreUnitOfWork;
        }

        public void AddAnOrder(Order order)
        {
            _medicineStoreUnitOfWork.OrderRepository.Add(order);
            _medicineStoreUnitOfWork.Save();
        }

        public object GetAllStocks()
        {
            throw new NotImplementedException();
        }

        public int GetAvailableQuantity(int id)
        {
            var medicineStock=_medicineStoreUnitOfWork.StockRepository.GetById(id);
            return medicineStock.Quantity;
        }

        public Medicine GetMedicine(int id)
        {
            return _medicineStoreUnitOfWork.MedicineRepository.GetByIdWithIncludeProperty(x => x.Id == id, "Categories,PriceDiscount,Image");
        }

        public void UpdateMedicineStock(int medicineId, int quantity)
        {
            var medicine = _medicineStoreUnitOfWork.MedicineRepository.GetByIdWithIncludeProperty(x=>x.Id==medicineId,"Stock");
            var medicineStock = _medicineStoreUnitOfWork.StockRepository.GetById(medicine.Stock.Id);
            medicineStock.Quantity -= quantity;
            _medicineStoreUnitOfWork.Save();
        }
    }
}
