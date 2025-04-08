#include <iostream>
#include <vector>
#include <algorithm>
#include <unordered_map>
#include "single_number.hpp"

int singleNumber(const std::vector<int>& vec) {
  std::unordered_map<int, int> numFreq;
    for (int num : vec) {
        numFreq[num]++;
    }
    for (auto same : numFreq) {
        if (same.second == 1) {
            return same.first;
        }
    }
    return -1;
}