#include <vector>
#include "missing.hpp"

// When the input vector is of size n 
// you are guaranteed that it contains all 
// of the integers 0, 1, 2, ..., n except for one.
// The goal of whoIsMissing is to return the missing number
int whoIsMissing(const std::vector<int>& nums) {
  int sum = nums.size()*(nums.size() + 1) / 2; 
  int realSum = 0;
  for (int index = 0; index < nums.size(); index++) {
    realSum += nums[index];
  }
  return sum - realSum;
}