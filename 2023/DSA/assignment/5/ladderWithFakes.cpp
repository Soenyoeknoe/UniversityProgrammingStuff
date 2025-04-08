#include <iostream>
#include <utility>
#include <vector>
#include <string>
#include <algorithm>
#include <fstream>
#include <queue>
#include <map>
#include <numeric>
#include <functional>
#include <unordered_map>
#include <unordered_set>
#include <set>
#include <cassert>
#include "ladderWithFakes.hpp"

// default initialiser does not need to do anything
LadderWithFakes::LadderWithFakes() = default;

// initialise any private member variables you want 
// in order to be ready to compute shortest paths with fakes
LadderWithFakes::LadderWithFakes(const std::string& inputFile) {
  std::ifstream infile(inputFile);// constructor takes an input file path of `4words.txt` as a parameter and reads n content of the file.
  std::vector<std::string> words {};
  std::string word;
  // read content of the file
  while(getline(infile, word)) {
    map.insert(std::make_pair(word, word));
  }//The overall complexity of this function is O(n)
}
//helper function that returns a vector of valid words that can be formed from the input word by changing a single character.
std::vector<std::string> LadderWithFakes::ifWordsValid(const std::string word) {
    std::vector<std::string> validWordsList;
    int validCheckerIterator = 0;
    while(validCheckerIterator < 4) {//It iterates over the characters of the word and replaces each character with all lowercase alphabets but not the the original character.
        std::string temporaryWord = word;
        char characterValidChecker = 'a';
        while(characterValidChecker <= 'z') {
            if(temporaryWord[validCheckerIterator] == characterValidChecker) {
              characterValidChecker++;
              continue;
            }
            temporaryWord[validCheckerIterator] = characterValidChecker;
            if(map.find(temporaryWord) != map.end()) {
                validWordsList.push_back(temporaryWord);
            }
            characterValidChecker++;
        }
        validCheckerIterator++;
    }
    //It checks if the resulting word exists in the map and adds it to the valid words list if found.
    return validWordsList;
}//The overall complexity of this function is O(1)

//helper function that returns a vector of all possible words that can be formed from the input word by changing a single character
std::vector<std::string> LadderWithFakes::listAllWords(const std::string word) {
  std::vector<std::string> allWordsVector;
    int wordIndex = 0;
    while (wordIndex < 4) {//It iterates over the characters of the word and replaces each character with all lowercase alphabets.
      std::string temporaryWord = word;
      char characterWord = 'a';
      while (characterWord <= 'z') {
        if (temporaryWord[wordIndex] != characterWord) {
            temporaryWord[wordIndex] = characterWord;
            allWordsVector.push_back(temporaryWord);
        }
          characterWord++;
      }
      wordIndex++;
    }
    //finally it adds each generated word to the vector.
    return allWordsVector;
}//The overall complexity of this function is O(1)

//This function reconstructs and returns the path from the end word to the start word by following the word history.
std::vector<std::string> LadderWithFakes::getTheHistory(const std::string end, const std::string start, const std::map<std::string, std::string>& history) {
    std::vector<std::string> path;
    std::string currentWord = end;
    while(currentWord != start) {
        path.push_back(currentWord);
        currentWord = history.at(currentWord);
    }
    path.push_back(start);
    std::reverse(path.begin(), path.end());
    return path;
}//The overall complexity of this function is O(n)

//This function calculates and returns an estimate of the number of character differences between two words.
int heuristicEstimator(const std::string& conterIndex1, const std::string& conterIndex2) {
    int counter = 0;
    int heuristicIndex = 0;
    while(heuristicIndex < 4) {// It compares the characters at corresponding positions in both words and increments a counter if they differ. 
        if(conterIndex2[heuristicIndex] != conterIndex1[heuristicIndex]){
            counter++;
        }
        heuristicIndex++;
    }
    //The final count represents the heuristic estimate.
    return counter;
}//The overall complexity of this function is O(1)

// given two strings and a budget of fake words k, find the shortest 
// path between the two strings using at most k fake words
// the function takes an origin word, destination word, and a budget k for fake words. 
std::vector<std::string> LadderWithFakes::shortestPathWithFakes(const std::string &origin, const std::string &dest, int k) {
    using Distance = std::pair<int, int>;
    std::priority_queue<std::pair<Distance, std::pair<std::string, int>>, std::vector<std::pair<Distance, std::pair<std::string, int>>>, std::greater<std::pair<Distance, std::pair<std::string, int>>>> queuePriority;
    queuePriority.push({{0, 0}, {origin, 0}});// uses a priority queue to perform an A search algorithm to find the shortest path and stores pairs of distance and word information. 
    std::map<std::string, int> greatDistanceTo = {{origin, heuristicEstimator(origin, dest)}};// variable that keeps track of the best known distance to each word
    std::map<std::string, std::string> pathHistory;//  variable that used to stores the previous word in the path for each word
    // the block is iteratively expands nodes from the priority queue until either the destination word is found or the queue becomes empty as it generates the next possible words from the current word based on the k and checks if each generated word has a better distance estimate than the current known distance. 
    // the block basically terminates by returning an empty vector if no path is found.
    while (!queuePriority.empty()) {
        const auto queueTop = queuePriority.top();
        queuePriority.pop();
        if (queueTop.second.first == dest) {
            return getTheHistory(dest, origin, pathHistory);
        }else if (queueTop.first.first > greatDistanceTo[queueTop.second.first]) {
            continue;
        }
        std::vector<std::string> nextVertex;
        int fakeWord = queueTop.second.second;
        if (fakeWord < k) {
            nextVertex = listAllWords(queueTop.second.first);
        } else {
            nextVertex = ifWordsValid(queueTop.second.first);
        }
        auto vertexIterator = nextVertex.begin();
        while (vertexIterator != nextVertex.end()) {
            const std::string& movingToVertex = *vertexIterator;
            int nextFakeWordsUsed;
            if (map.count(movingToVertex) > 0) {
                nextFakeWordsUsed = fakeWord;
            } else {
                nextFakeWordsUsed = fakeWord + 1;
            }
            int nextHeuristic = heuristicEstimator(movingToVertex, dest);
            Distance nextDestination = {queueTop.first.second + nextFakeWordsUsed + nextHeuristic, queueTop.first.second + 1};
            std::pair<std::string, int> nextWord = {movingToVertex, nextFakeWordsUsed};
            if (!greatDistanceTo.count(nextWord.first) || nextDestination.first < greatDistanceTo[nextWord.first]) {
                greatDistanceTo[nextWord.first] = nextDestination.first;
                pathHistory[nextWord.first] = queueTop.second.first;
                queuePriority.push({nextDestination, nextWord});
            }

            ++vertexIterator;
        }
    }
    return {};//The overall complexity of this function is O(E log V), where E is the number of edges (iterations in while loop) and V is the number of vertices (size of the queuePriority)
    // return the shortest path.
}
