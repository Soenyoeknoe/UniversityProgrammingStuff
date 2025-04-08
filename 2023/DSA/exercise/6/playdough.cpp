#include <vector>
#include <queue>
#include <algorithm>
#include "playdough.hpp"

int lastBallWeight(const std::vector<int>& weights) {
  std::priority_queue<int> impQueue;
    for (int i : weights) {
        impQueue.push(i);
    }
    while (impQueue.size() > 1) {
        int number1 = impQueue.top();
        impQueue.pop();
        int number2 = impQueue.top();
        impQueue.pop();
        if (number1 == number2) {
        } else {
            impQueue.push(number1 - number2);
        }
    }
    if (impQueue.empty()) {
        return 0;
    } else {
        return impQueue.top();
    }
    
}
