using Meetins.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetins.Core.Data
{
    public interface IDataContext
    {
        /// <summary>
        /// Соответствует таблице Events.KudagoInvites.
        /// </summary>
        public DbSet<KudagoInvites> KudagoInvites { get; set; }

        /// <summary>
        /// Соответствует таблице Events.EventsCategories.
        /// </summary>
        public DbSet<EventsCategoryEntity> EventsCategories { get; set; }

        /// <summary>
        /// Соответствует таблице Events.EventsToUsers.
        /// </summary>
        public DbSet<EventsToUsersEntity> EventsToUsers { get; set; }

        /// <summary>
        /// Соответствует таблице Events.Events.
        /// </summary>
        public DbSet<EventEntity> Events { get; set; }

        /// <summary>
        /// Соответствует таблице Messenger.Messages.
        /// </summary>
        public DbSet<MessageEntity> Messages { get; set; }

        /// <summary>
        /// Соответствует таблице Messenger.MessageContents.
        /// </summary>
        public DbSet<MessageContentsEntity> MessageContents { get; set; }

        /// <summary>
        /// Соответствует таблице Messenger.DialogMembers.
        /// </summary>
        public DbSet<DialogMembersEntity> DialogMembers { get; set; }

        /// <summary>
        /// Соответствует таблице Messenger.Dialogs.
        /// </summary>
        public DbSet<DialogEntity> Dialogs { get; set; }

        /// <summary>
        /// Соответствует таблице Info.About.
        /// </summary>
        public DbSet<AboutEntity> Abouts { get; set; }

        /// <summary>
        /// Соответствует таблице dbo.Logs.
        /// </summary>
        public DbSet<LogEntity> Logs { get; set; }

        /// <summary>
        /// Соответствует таблице User.Users.
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// Соответствует таблице dbo.Cities.
        /// </summary>
        public DbSet<CityEntity> Cities { get; set; }

        /// <summary>
        /// Соответствует таблице dbo.Reports
        /// </summary>
        public DbSet<ReportEntity> Reports { get; set; }

        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }

        public Task<int> SaveAllChangesAsync();

        public ValueTask<EntityEntry> AddAllAsync(object entity);
    }
}
