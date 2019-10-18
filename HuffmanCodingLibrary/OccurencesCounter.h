#pragma once
#include <queue>
#include <vector>
#include "Sign.h"
#include <string>

namespace HuffmanTmp {

	class OccurencesCounter {

	private:
		std::vector<Sign> vecSignContainer;
		std::vector<Sign> vecTmpSignContainer;
		std::priority_queue<Sign*, std::vector<Sign*>, Sign::CustomPqComparator> pqSignContainer;
	public:
		OccurencesCounter(std::string inputSeries);

		std::priority_queue<Sign*, std::vector<Sign*>, Sign::CustomPqComparator>* GetPqSignContainer() {
			return &pqSignContainer;
		}

	};


}