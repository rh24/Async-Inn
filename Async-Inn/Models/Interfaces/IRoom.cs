using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;

namespace AsyncInn.Interfaces
{
    public interface IRoom
    {
        /// <summary>
        /// CREATE
        /// </summary>
        /// <param name="room">Accepts a room object</param>
        /// <returns>Task object that is useful for async actions. Task objects do not actually have a return value.</returns>
        Task CreateRoom(Room room);

        /// <summary>
        /// READ
        /// </summary>
        /// <returns>Task<TResult> represents a single action that has returns a value identified within the angle brackets. In this case, the Task object holds an IEnumerable collection of Room objects.</returns>
        Task<IEnumerable<Room>> GetRooms();

        /// <summary>
        /// READ - grab a single hotel by id
        /// </summary>
        /// <param name="id">room's id</param>
        /// <returns>Task object</returns>
        Task GetRoom(int? id);

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="room">room object to update</param>
        /// <returns>Task object with no return value</returns>
        Task UpdateRoom(Room room);

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id">id of room to delete from db</param>
        /// <returns>Task object</returns>
        Task DeleteRoom(int id);
    }
}
