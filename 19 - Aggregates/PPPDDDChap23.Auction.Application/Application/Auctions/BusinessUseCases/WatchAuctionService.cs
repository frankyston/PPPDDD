﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPPDDDChap23.Auction.Application.Model.Members;
using PPPDDDChap23.Auction.Application.Model.Auctions;
using PPPDDDChap23.Auction.Application.Model.Members.Watching;

namespace PPPDDDChap23.Auction.Application.Application.Auctions.BusinessUseCases
{
    public class WatchAuctionService
    {
        private IAuctionRepository _auctions;
        private IMemberRepository _members;
        private IWatchedItemRepository _watchedItems;
        // private IDocumentSession _unitOfWork;

        public WatchAuctionService(IAuctionRepository auctions, IMemberRepository members, IWatchedItemRepository watchedItems)
        {
            _auctions = auctions;
            _members = members;
            _watchedItems = watchedItems;
            // _unitOfWork = unitOfWork;
        }

        public void Watch(WatchAuction command)
        {
            // Ensure Auction exisits
            var auction = _auctions.FindBy(command.AuctionId);
            // Ensure Seller exisits
            var member = _members.FindBy(command.MemberId);

            var watchItem = auction.Watch(command.MemberId);

            _watchedItems.Add(watchItem);
          
            // _unitOfWork.SaveChanges();
        }
    }
}