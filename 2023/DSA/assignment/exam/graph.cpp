#include <iostream>
#include <fstream>
#include <utility>
#include <functional>
#include <vector>
#include <unordered_map>
#include <queue>
#include <string>
#include <set>
#include <limits>
#include "graph.hpp"

// verify returns true if distTo[i] is the length of a shortest path from 
// vertex 0 to vertex i in the graph G, and false otherwise.  Return false 
// if G contains a negative weight cycle.
// assumptions: 
//   1. All vertices are reachable from 0
//   2. distTo[i] is an upper bound on the length of a shortest path 
//        from 0 to i
// *** For you to implement
bool verify(const std::vector<int>& distTo, const Graph& G) {
  const int graphSize = G.size();

  std::vector<int> currentDist(graphSize, std::numeric_limits<int>::max());
  currentDist[0] = 0;//Sets the source vertex 0 as 0.
  std::vector<int> inDaQueue(graphSize, 0);//initialize vector of graphSize element and set all to 0
  std::deque<int> deque;
  deque.push_back(0);
  inDaQueue[0] = 1;
  //create a deque of integer
  std::vector<int> counter(graphSize, 0);//initialize counter vector of graphSize element and set all to 0
  //check if the deque is empty
  while (!deque.empty()) {
    int vertex = deque.front();
    deque.pop_front();
    inDaQueue[vertex] = 0;
    //retrive the front of the deque while update the inDaQueue so it was not in deque now
    for (const auto& [neighbour, weight] : *(G.neighbours(vertex))) {
      int newDist = currentDist[vertex] + weight;//Calculates the new distance from the source vertex to the neighboring vertex
      //check if the new distance is less than the current distance
      if (newDist < currentDist[neighbour]) {
        currentDist[neighbour] = newDist;//update the distance of the neighboring vertex to the new distance.
        //update the counter for the vertex
        if (!inDaQueue[neighbour]) {
          //check if the counter exceeds the graph size which means there is negative weight detected
          if (++counter[neighbour] >= graphSize){
            return false;
          }
          // neighboring vertex is added to the front of the deque if its not empty
          if (!deque.empty() && currentDist[neighbour] < currentDist[deque.front()]){
            deque.push_front(neighbour);
          }
          //Otherwise, it is added to the back of the deque
          else{
            deque.push_back(neighbour);
          }
          inDaQueue[neighbour] = 1;
        }
      }
    }
  }
  // checks if the computed distances match the provided distTo vector. It returns true if they are equal and false otherwise.
  return std::equal(currentDist.begin(), currentDist.end(), distTo.begin());
}

// construct empty graph with n vertices
Graph::Graph(int n) : 
    adjList {std::vector<std::unordered_map<int, int> >(n)} {}

void Graph::addEdge(int from, int to, int weight) {
  int n = size();
  if (from >= 0 && from < n && to >= 0 && to < n) {
    adjList.at(from).insert({to, weight});
  }
}

int Graph::size() const {
  return static_cast<int>(adjList.size());
}

std::ostream& operator<<(std::ostream& out, const Graph& G) {
  for (int i = 0; i < G.size(); ++i) {
    out << i << ':';
    for (const auto& [neighbour, weight] : *(G.neighbours(i))) {
      out << " (" << i << ", " << neighbour << ")[" << weight << ']';
    }
    out << '\n';
  }
  return out;
}

