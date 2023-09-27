using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGShotManager
{
    private List<SGShotCtrl> m_shotList = new List<SGShotCtrl>(2048);           //총알을 2048개까지 관리하는 리스트
    private HashSet<SGShotCtrl> m_shotHashSet = new HashSet<SGShotCtrl>();          //hashset 값으로 샷 컨트롤 리스트 관리
    public int activeShotCount { get { return m_shotList.Count; } }         //activeshot 접근 할경우 갯수리턴

    public void UpdateShots(float deltaTime)            //총알 쏜것 업데이트 지속적으로 시켜주고 지워야 할경우 지움
    {
        for (int i = m_shotList.Count - 1; i >= 0; i--)
        {
            SGShotCtrl shotCtrl = m_shotList[i];
            if (shotCtrl == null)
            {
                m_shotList.Remove(shotCtrl);
                continue;
            }
            shotCtrl.UpdateShot(deltaTime);
        }
    }

    public void AddShot(SGShotCtrl shotCtrl)                        //AddShot Hastset 에서 더해지는것들 추가하는 함수
    {
        if (m_shotHashSet.Contains(shotCtrl))
        {
            return;
        }
        m_shotList.Add(shotCtrl);
        m_shotHashSet.Add(shotCtrl);
    }
   
    public void RemoveShot(SGShotCtrl shotCtrl)                 //HashSet에서 제거하는 함수
    {
        if (m_shotHashSet.Contains(shotCtrl) == false)
        {
            return;
        }
        m_shotList.Remove(shotCtrl);
        m_shotHashSet.Remove(shotCtrl);
    }
}
