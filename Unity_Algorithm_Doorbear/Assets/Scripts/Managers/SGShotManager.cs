using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGShotManager
{
    private List<SGShotCtrl> m_shotList = new List<SGShotCtrl>(2048);           //�Ѿ��� 2048������ �����ϴ� ����Ʈ
    private HashSet<SGShotCtrl> m_shotHashSet = new HashSet<SGShotCtrl>();          //hashset ������ �� ��Ʈ�� ����Ʈ ����
    public int activeShotCount { get { return m_shotList.Count; } }         //activeshot ���� �Ұ�� ��������

    public void UpdateShots(float deltaTime)            //�Ѿ� ��� ������Ʈ ���������� �����ְ� ������ �Ұ�� ����
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

    public void AddShot(SGShotCtrl shotCtrl)                        //AddShot Hastset ���� �������°͵� �߰��ϴ� �Լ�
    {
        if (m_shotHashSet.Contains(shotCtrl))
        {
            return;
        }
        m_shotList.Add(shotCtrl);
        m_shotHashSet.Add(shotCtrl);
    }
   
    public void RemoveShot(SGShotCtrl shotCtrl)                 //HashSet���� �����ϴ� �Լ�
    {
        if (m_shotHashSet.Contains(shotCtrl) == false)
        {
            return;
        }
        m_shotList.Remove(shotCtrl);
        m_shotHashSet.Remove(shotCtrl);
    }
}