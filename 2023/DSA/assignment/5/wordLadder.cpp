#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <algorithm>
#include <queue>
#include <map>
#include <numeric>
#include <unordered_map>
#include <unordered_set>
#include <set>
#include "wordLadder.hpp"

// default constructor done for you
WordLadder::WordLadder() = default;

WordLadder::WordLadder(const std::string& inputFile) {
  // we provide a template to demonstrate how to read from a file
  std::ifstream infile(inputFile);
  std::vector<std::string> words {};
  std::string word {};
  while (infile >> word) {
    words.push_back(word);
  }
  // now all the words in inputFile are in the vector words...
  // This block basically iterating over the words and building the graph
  auto inputIterator = words.begin();
  while (!(inputIterator == words.end())) {
    const auto daWords = *inputIterator;
    addVertex(daWords);
    int wordSizeChecker = 0;
    while (wordSizeChecker < daWords.size()) {
      std::string temporaryString = daWords;
      char character = 'a';
      do {
        temporaryString[wordSizeChecker] = character;
        if (isVertex(temporaryString)) {
          addEdge(daWords, temporaryString);
        }
        character++;
      } while (character <= 'z');
      wordSizeChecker++;
    }
    ++inputIterator;
  }
}

// add vertex to adjList with empty neighbor set
// if it is not already present.  Otherwise, do nothing.
// function to check if the vertex is already present in the map
void WordLadder::addVertex(const std::string& word) { 
  do {//The overall complexity of this function is O(1) on average as it was due to unordered_map.
    map[word];
  }
  while(map.find(word) == map.end());
}
// the function was to add an edge between two vertices if they exist in the map.
void WordLadder::addEdge(const std::string& a, const std::string& b) {
  if(!(isVertex(a) && isVertex(b))){//Checking if both vertices are present in the map with the time complexity of O(1) on average due to unordered_map.
    return;
  } 
  if(a == b){
    return;
  }
  //as it was using undordered_set in inserting edges with the time complexity is O(1)
  map[a].insert(b);
  map[b].insert(a);
}
// Remove a vertex and all its associated edges from the map
void WordLadder::removeVertex(const std::string& a) {
  if(!isVertex(a)){//Checking if the vertex is present in the map with O(1) time complexity 
    return;//The return statement exits the function immediately after removing the vertex and all its associated edges from the map data structure.
  } 
  //Removing edges associated with the vertex of O(vertexIterator*adjacentVertices)
  auto vertexIterator = map.find(a);
  if (!(vertexIterator == map.end())) {
    do {
      const auto& adjacentVertices = vertexIterator->second;
      for (auto adjacentIterator = adjacentVertices.begin(); adjacentIterator != adjacentVertices.end(); adjacentIterator++) {
        map[*adjacentIterator].erase(a);
      }
      map.erase(vertexIterator++);
    } while (vertexIterator != map.end() && vertexIterator -> first == a);
  }
}
// This function is to check if an edge exists between two vertices.
bool WordLadder::isEdge(const std::string& a, const std::string& b) const {
  //It was using undordered_map in check if an edge exists between two vertices with the time complexity is O(1) on average
  if(map.find(a) == map.end()){
    return false;
  } 
  auto daEdge = map.find(a);
  return daEdge -> second.find(b) != daEdge -> second.end();
}
// this function is to check if a vertex exists in the map
bool WordLadder::isVertex(const std::string& a) const {
  //It was using undordered_map in check if an vertex exists between two vertices with the time complexity is O(1) on average
  return map.find(a) != map.end();
}
// Get the shortest path from origin to destination using BFS.
std::vector<std::string>
WordLadder::getShortestPath(const std::string& origin,
                            const std::string& dest) {
  
  std::vector<std::string> emptyVector;
  std::queue<std::pair<std::string, std::vector<std::string> > > theQueue;
  std::set<std::string> nodeVisited;
  std::vector<std::string> pathHistory;
  pathHistory.push_back(origin);
  theQueue.push(std::make_pair(origin, pathHistory));
  nodeVisited.insert(origin);
  while(!theQueue.empty()) {
    std::string currentNode = theQueue.front().first;
    std::vector<std::string> currentHistory = theQueue.front().second;
    theQueue.pop();
    if(currentNode == dest){
      return currentHistory;
    }
    for (const auto& neighbor : map[currentNode]) {
      if (nodeVisited.find(neighbor) == nodeVisited.end()) {
        nodeVisited.insert(neighbor);
        std::vector<std::string> nextHistory = currentHistory;
        nextHistory.push_back(neighbor);
        theQueue.push({neighbor, nextHistory});
      }
    }
  }// Overall, it uses time compexity of O(V + E), where V is the number of vertices and E is the number of edges.
  return emptyVector;
}

// Get the shortest path from origin to destination using BFS.
std::map<std::string, int> WordLadder::listComponents() {
  std::map<std::string, int> connectedComponents;
  std::set<std::string> componentVisited;
  auto mapListIterator = map.begin();
  while (!(mapListIterator == map.end())) {
    if (componentVisited.find(mapListIterator -> first) == componentVisited.end()) {
      int numberOfNodes = 0;
      std::queue<std::string> stringQueue;
      stringQueue.push(mapListIterator->first);
      do {
        std::string currentNode = stringQueue.front();
        stringQueue.pop();
        if (componentVisited.find(currentNode) != componentVisited.end()) {
          continue;
        }
        numberOfNodes++;
        componentVisited.insert(currentNode);
        for (const std::string& nextNode : map[currentNode]) {
          if (componentVisited.find(nextNode) == componentVisited.end()) {
            stringQueue.push(nextNode);
          }
        }
      } while (!stringQueue.empty());
      connectedComponents[mapListIterator -> first] = numberOfNodes;
    }
    ++mapListIterator;
  }
  // Same as the function above, it uses time compexity of O(V + E), where V is the number of vertices and E is the number of edges.
  return connectedComponents;
}
