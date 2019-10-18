#include "OccurencesCounter.h"
#include <set>
#include <iostream>
#include "HuffmanTree.h"
#include "HuffmanTree.h"

namespace HuffmanTmp {

	OccurencesCounter::OccurencesCounter(std::string inputSeries) {

		for (char character : inputSeries)
		{
			vecTmpSignContainer.push_back(Sign(character, 0, nullptr, nullptr));
		}

		for (Sign sign : vecTmpSignContainer)
		{
				Sign currentSign = sign;

				for (Sign internalSign : vecTmpSignContainer)
				{

					if (currentSign.GetSign() == internalSign.GetSign())
					{
						currentSign.IncreaseNumOfOccurences();
					}

				}

				vecSignContainer.push_back(currentSign);
		}

		vecTmpSignContainer.clear();

		std::set<Sign> tmpSet(vecSignContainer.begin(), vecSignContainer.end());
		vecSignContainer.assign(tmpSet.begin(), tmpSet.end());

		for (int i = 0; i < vecSignContainer.size(); i++)
		{
			pqSignContainer.push(&vecSignContainer[i]);
		} 

		//HuffmanTmp::HuffmanTree newTree(&pqSignContainer);
		
	}

}