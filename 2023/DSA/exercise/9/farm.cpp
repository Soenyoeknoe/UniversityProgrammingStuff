#include <utility>
#include <vector>
#include <queue>
#include <set>
#include <algorithm>
#include "farm.hpp"

// *** For you to implement
std::vector<Inventory> getNeighbours(Inventory p) {
  // return all the states that can be reached from p in one day
  // each day you receive one new bale of hay and one egg for each 
  // chicken you have
  p.hay++;
  std::vector<Inventory> checkBarn;
  p.eggs += p.chickens;
  // you can then take one of the following actions:

  // 1. Do nothing 
  // 2. Trade 2 bales of hay for 1 chicken.
  Inventory trade1 = p;
  Inventory trade2 = p;
  Inventory trade3 = p;
  if(trade1.hay >= 2) {
      trade1.hay -= 2, trade1.chickens++;
      checkBarn.push_back(trade1);
  }
  // 3. Trade 1 bale of hay for 2 eggs.
  if(trade2.hay >= 1) {
      trade2.hay--, trade2.eggs += 2;
      checkBarn.push_back(trade2);
  }
  // 4. Trade 3 eggs for 1 chicken
  if(trade3.eggs >= 3) {
      trade3.eggs -= 3,trade3.chickens++;
      checkBarn.push_back(trade3);
  }
  // You cannot go into debt.  For example, to trade 2 bales of hay 
  // for a chicken you must have at least 2 bales of hay.
  return checkBarn;
}

int daysForEggs(const Inventory& origin, int numberOfEggs) {
  // queue holding vertices to be explored
  // First item of pair is an inventory, second item is distance
  // of the item from origin
  std::queue<std::pair<Inventory, int> > inventoryQueue {};
  inventoryQueue.push({origin, 0});
  // record how we arrived at an Inventory. We first reach v from prev[v].
  // This is not needed for the exercise, but may help with your debugging
  std::map<Inventory, Inventory> prev {};
  // record the Inventories that have already been visited
  // visited means you have previously been put into the queue
  std::set<Inventory> visited {origin};
  while (!inventoryQueue.empty()) {
    auto [current, dist] = inventoryQueue.front();
    inventoryQueue.pop();
    if (current.eggs >= numberOfEggs) {
      // For debugging you can see the path taken:
      // for (Inventory state = current; state != origin; state = prev[state]) {
      //   std::cout << state;
      //   std::cout << '\n';
      // }
      // std::cout << origin;
      return dist;
    }
    // Here is where the function you implement is used
    std::vector<Inventory> neighbours = getNeighbours(current);
    for (Inventory neighbour : neighbours) {
      if (!visited.contains(neighbour)) {
        prev[neighbour] = current;
        visited.insert(neighbour);
        // if not visited, the distance of neighbour from the origin is 
        // one plus the distance from the origin of the node from which 
        // we visit neighbour
        inventoryQueue.push({neighbour, dist + 1});
      }
    }
  }
  // should not reach here on a valid input
  return -1;
}