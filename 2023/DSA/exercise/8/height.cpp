#include <algorithm>
#include "height.hpp"

int height(Node* root) {
  if (root == nullptr) {
    return -1;
  }
  auto left = height(root->left)+1;
  auto right = height(root->right)+1;
  if(left<right)
  {
    return right;
  }
  else {
    return left;
  }
}