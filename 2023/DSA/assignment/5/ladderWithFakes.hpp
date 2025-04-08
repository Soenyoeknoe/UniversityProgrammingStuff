#ifndef LADDER_WITH_FAKES_HPP_
#define LADDER_WITH_FAKES_HPP_

#include <vector>
#include <string>
#include <queue>
#include <list>
#include <deque>
#include <map>
#include <unordered_map>
#include <set>
#include <unordered_set>

struct Distance {
    int a;
    int b;
    auto operator <=> (const Distance& other) const = default;
};

class LadderWithFakes {
 private:
  // add some private member variables if needed
  std::unordered_map<std::string, std::string> map;//this was used to represent the map of the graph
  std::vector<std::string> ifWordsValid(const std::string word);//this was used as helper function
  std::vector<std::string> listAllWords(const std::string word);//this was used as helper function
  std::vector<std::string> getTheHistory(const std::string end, const std::string start, const std::map<std::string, std::string>& history);//This function reconstructs and returns the path from the end word to the start word by word history.
 public:
  LadderWithFakes();

  // initialise any private member variables you want 
  // in order to be ready to compute shortest paths with fakes
  explicit LadderWithFakes(const std::string&);

  // given two strings and a budget of fake words k, find the shortest 
  // path between the two strings using at most k fake words
  std::vector<std::string> shortestPathWithFakes(const std::string&, const std::string&, int k);
};

#endif      // LADDER_WITH_FAKES_HPP_
