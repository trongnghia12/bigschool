﻿using bigschool.DTOs;
using bigschool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace bigschool.Controllers
{
    public class FollowingsController : ApiController
    {
        // GET: Followings
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exist!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}