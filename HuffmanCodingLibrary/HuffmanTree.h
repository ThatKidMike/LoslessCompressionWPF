#pragma once
#include "OccurencesCounter.h"

namespace HuffmanTmp {

	class HuffmanTree {

	private:
		Sign* apex;

	public:
		HuffmanTree(std::priority_queue<Sign*, std::vector<Sign*>, Sign::CustomPqComparator>* pqSignContainer);

		Sign* GetApex();

	};

}
