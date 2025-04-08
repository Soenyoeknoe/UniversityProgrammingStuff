#include <iostream>
#include <vector>
#include <string>
#include "myDeque.hpp"

// default constructor (nothing to do here)
template <typename T>
MyDeque<T>::MyDeque() {}

// construct a zero-initialized deque of size n
template <typename T>
MyDeque<T>::MyDeque(int n ) {   
  int dequeDeck = 0;    
  while (dequeDeck < n) {     //use while loop to initialize the size of n in run the deque
        frontVector.push_back(T());
        dequeDeck++;  
  }
}

// Constructor from initializer list
template <typename T>
MyDeque<T>::MyDeque(std::initializer_list<T> vals) {
  for (auto integerVec = std::rbegin(vals); integerVec != std::rend(vals); ++integerVec) {  //The std::rbegin() and std::rend() functions are used to iterate over the initializer_list in reverse order. 
        frontVector.push_back(*integerVec); // frontVector member variable being initialized with the values from the initializer_list in reverse order, with the last value in the initializer_list becoming the first element of frontVector.
    }   
}

//push_back function adds a new element to the end of the deque.
template <typename T>
void MyDeque<T>::push_back(T val) {
  backVector.push_back(val);//The overall complexity of this function is O(1)
}
//push_front fuctions add a new elemets to the front of the deque.
template <typename T>
void MyDeque<T>::push_front(T val) {
  frontVector.push_back(val);//The overall complexity of this function is O(1)
}
//pop_back function remove the last elements of the deque 
template <typename T>
void MyDeque<T>::pop_back() {
  if(frontVector.size() == 0 && backVector.size() == 0) { // the function checks if both front and back vectors are empty. If so, it returns without doing anything.
      return;
  }
  if(backVector.size() == 0 && frontVector.size() == 1) { //if only the back vector is empty and the front vector has only one element, it removes that element and returns.
      frontVector.pop_back();
      return;
  }
  if(backVector.size() == 0) {
      int vectorSize = frontVector.size(); //If the back vector is empty but the front vector has multiple elements,
      int resizeSplit = vectorSize / 2;// the function splits the front vector into two halves and moves the elements from the first half to the back vector in reverse order. 
      int backIndex = resizeSplit - 1;
      int endIndex = backIndex + 1;
      int vectorIndex = 0, runTime = resizeSplit;   
      while(backIndex >= 0) {
          backVector.push_back(frontVector[backIndex]);//Then, it removes the elements from the first half from the front vector.
          backIndex--;
      }
      if(vectorSize % 2 == 1) {
          runTime++;
      }
      while(vectorIndex < runTime) {
          frontVector[vectorIndex] = frontVector[endIndex + vectorIndex];
          vectorIndex++;
      }
      for(int i = 0; i < resizeSplit; i++) {
          frontVector.pop_back();
      }
    }
    backVector.pop_back();//The overall complexity of this function is O(N)
}

//The pop_front() function removes the first element of the deque
template <typename T>
void MyDeque<T>::pop_front() {
    if(frontVector.size() == 0 && backVector.size() == 0) {// the function checks if both front and back vectors are empty. If so, it returns without doing anything.
        return;
    }
    if(frontVector.size() == 0 && backVector.size() == 1) {//if only the back vector is empty and the front vector has only one element, it removes that element and returns.
        backVector.pop_back();
        return;
    }
    if(frontVector.size() == 0) { //If the front vector is empty but the front vector has multiple elements,
      int vectorSize = backVector.size(); // the function splits the back vector into two halves and moves the elements from the first half to the front vector in reverse order. 
      int resizeSplit = vectorSize / 2;
      int frontIndex = resizeSplit - 1;
      int nextIndex = frontIndex + 1;  
      int vectorIndex = 0, runTill = resizeSplit;         
        while(frontIndex >= 0) {
            frontVector.push_back(backVector[frontIndex]);//Then, it removes the elements from the first half from the front vector.
            frontIndex--;
        }
        
        if(vectorSize % 2 == 1) {
            runTill++;
        } 
        while(vectorIndex < runTill) {
            backVector[vectorIndex] = backVector[nextIndex + vectorIndex];
            vectorIndex++;
        } 
        for(int i = 0; i < resizeSplit; i++) {
            backVector.pop_back();
        }
    }
    frontVector.pop_back();//The overall complexity of this function is O(N)
}

template <typename T>
T& MyDeque<T>::back() { // Function that return the last element by reference
  if(backVector.size() > 0) {
        int backSizeVec = backVector.size();
        return backVector[backSizeVec - 1];
    } 
    else if(frontVector.size() > 0) {
        return frontVector[0];
    }
    return frontVector[0]; //Overall, The time complexity of the back() function is constant time, O(1), because it only needs to access the last element of the backVector if it is not empty, or the first element of the frontVector if the backVector is empty. 
}

template <typename T>
const T& MyDeque<T>::back() const { //function that return the last element by const reference depending on whether the function is called on a const object or not. 
  if(backVector.size() > 0) {
        int backSizeVec = backVector.size();
        return backVector[backSizeVec - 1];
    } 
    else if(frontVector.size() > 0) {
        return frontVector[0];
    }
    return frontVector[0]; //The time complexity of this function is O(1) because it simply accesses the last element of the backVector or the first element of the frontVector, depending on which vector contains elements.
}

template <typename T>
T& MyDeque<T>::front() { //front() function has an issue with returning the first element of the deque. In the current implementation.
  if(frontVector.size() > 0) {
        int frontSizeVec = frontVector.size();
        return frontVector[frontSizeVec - 1];
    } 
    else if(backVector.size() > 0) { ////the function returns the last element of the frontVector if it's not empty, or the first element of the backVector if the frontVector is empty
        return backVector[0];
    }
  return frontVector[0];//The time complexity of the front() function is O(1) as it only accesses the first element of the deque, which is stored in the first position of the frontVector or the last position of the backVector
}

template <typename T>
const T& MyDeque<T>::front() const {// the fuctions return the first element by const reference, this one can be used on a const MyDeque
  if(frontVector.size() > 0) {
        int frontSizeVec = frontVector.size();
        return frontVector[frontSizeVec - 1];
    } 
    else if(backVector.size() > 0) {
        return backVector[0];
    }
  return frontVector[0];//The time complexity of const T& MyDeque<T>::front() const is O(1), because it only checks the size of the front and back vectors and returns the corresponding element based on the size
}
//The empty() function has a time complexity of O(1) since it only checks if the front and back vectors are empty.
template <typename T>
bool MyDeque<T>::empty() const {
  return frontVector.empty() && backVector.empty();
}
//The size() function has a time complexity of O(1) as well since it simply returns the sum of the sizes of the front and back vectors.
template <typename T>
int MyDeque<T>::size() const {
  return frontVector.size() + backVector.size();
}

template <typename T>
T& MyDeque<T>::operator[](int i) { //The functions's time complexity of this function is O(1) as it simply calculates which vector the desired element is in based on the given index i and then returns a reference to that element using the [] operator for the appropriate vector.
  int vecSize = frontVector.size(); 
  if(i < vecSize) {
        int operatorIndex = vecSize - i - 1;
        return frontVector[operatorIndex];
  } 
  else {
        return backVector[i - vecSize];
  }
}

template <typename T>
const T& MyDeque<T>::operator[](int i) const {//The const version of the operator[] function for MyDeque which returns a const reference to an element in the deque at index i.
  int vecSize = frontVector.size(); 
  if(i < vecSize) {
        int operatorIndex = vecSize - i - 1;
        return frontVector[operatorIndex];
  } 
  else {
        return backVector[i - vecSize]; // The time complexity of this function is O(1) since it only performs simple arithmetic calculations and returns a constant reference to an element in either the front or back vector.
  }
}


// Do not modify these lines.
// They are needed for the marker.
template class MyDeque<int>;
template class MyDeque<double>;
template class MyDeque<char>;
template class MyDeque<std::string>; 