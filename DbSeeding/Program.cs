// See https://aka.ms/new-console-template for more information
using Dal;
using DbSeeding.Parsers.Rooms;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

RoomParser roomParser = new RoomParser();
var rooms =  roomParser.GetRooms().ToList();

Context context = new Context();

await context.BulkInsertOrUpdateAsync(rooms);

var toDelete = await context.Rooms.Where(x => !rooms.Select(x => x.Id).Contains(x.Id))
    .ToArrayAsync();

await context.BulkDeleteAsync(toDelete);



await context.SaveChangesAsync();