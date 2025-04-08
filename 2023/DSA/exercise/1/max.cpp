#include <vector>
#include "max.hpp"

int maxValue(const std::vector<int>& vec) {
  // write your implementation here
    
    if (vec.empty()) {
        return 0;
    }
    
    int maxValue = vec[0];
    for (int i = 1; i < vec.size(); i++) {
        if (vec[i] > maxValue) {
            maxValue = vec[i];
        }
    }
    return maxValue;
}