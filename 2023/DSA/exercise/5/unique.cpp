#include <algorithm>
#include <string>
#include <unordered_map>
#include "unique.hpp"

std::size_t firstUniqueChar(const std::string& inputString) {
  // write your solution here
  std::unordered_map<char, std::size_t> count;
  for (char character : inputString) {
    count[character]++;
  }
  for (std::size_t i = 0; i < inputString.size(); i++) {
    if (count[inputString[i]] == 1) {
      return i;
    }
  }
  return inputString.size();
}
