#include "HuffmanTree.h"
#include "HuffmanTreeTraverse.h"
#include <iostream>

namespace HuffmanTmp {

	HuffmanTree::HuffmanTree(std::priority_queue<Sign*, std::vector<Sign*>, Sign::CustomPqComparator>* pqSignContainer) {

		Sign* leftSignPtr;
		Sign* rightSignPtr;

		while (pqSignContainer->size() != 1)
		{

			leftSignPtr = pqSignContainer->top();
			pqSignContainer->pop();
			rightSignPtr = pqSignContainer->top();
			pqSignContainer->pop();

			Sign* resultSign = new Sign((char)(leftSignPtr->GetNumOfOccurrences() + rightSignPtr->GetNumOfOccurrences()), leftSignPtr->GetNumOfOccurrences() + rightSignPtr->GetNumOfOccurrences(), leftSignPtr, rightSignPtr);
			pqSignContainer->push(resultSign);

		} 

		apex = pqSignContainer->top();
		pqSignContainer->pop();

		//std::cout << apex->GetLeftNode()->GetLeftNode()->GetLeftNode()->GetSign();

	}

	Sign* HuffmanTree::GetApex() {
		return apex;
	}

}