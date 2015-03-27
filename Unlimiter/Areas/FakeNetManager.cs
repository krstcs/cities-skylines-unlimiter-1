﻿using ColossalFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Unlimiter.Areas
{
    class FakeNetManager
    {
        private static int[] m_tileNodesCount = new int[17 * FakeGameAreaManager.GRID * FakeGameAreaManager.GRID];
        private static void AddTileNode(NetManager nm, Vector3 position, ItemClass.Service service, ItemClass.SubService subService)
        {
            if (service <= ItemClass.Service.Office)
                return;
            int areaIndex = Singleton<GameAreaManager>.instance.GetAreaIndex(position);
            if (areaIndex == -1)
                return;
            int num = areaIndex * 17;
            ++m_tileNodesCount[subService == ItemClass.SubService.None ? (int)(num + (service - 8 - 1)) : (int)(num + (subService - 9 - 1 + 12))];
        }
        public int GetTileNodeCount(NetManager nm, int x, int z, ItemClass.Service service, ItemClass.SubService subService)
        {
            int tileIndex = Singleton<GameAreaManager>.instance.GetTileIndex(x, z);
            if (tileIndex == -1)
                return 0;
            int num = tileIndex * 17;
            return m_tileNodesCount[subService == ItemClass.SubService.None ? (int)(num + (service - 8 - 1)) : (int)(num + (subService - 9 - 1 + 12))];
        }
    }
}