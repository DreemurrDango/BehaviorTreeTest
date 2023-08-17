using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Samples;

/// <summary>
/// ���߹��ܵ�ʵ��ģ�飬�����ܹ��ж��ĵ�λ����Ҫ���ظ�ģ��
/// </summary>
[RequireComponent(typeof(Unit))]
[RequireComponent(typeof(NavMeshAgent))]
public class Move : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�ƶ�·����ʾ���")]
    private LineRenderer movePathRender;

    [SerializeField,DisplayOnly]
    [Tooltip("�ƶ�Ŀ���α�")]
    private Transform targetT;
    [SerializeField, DisplayOnly]
    [Tooltip("�ƶ�Ŀ��λ��")]
    private Vector3 targetPos;

    /// <summary>
    /// �õ�λ�ϵĵ�λ���
    /// </summary>
    private Unit unit;
    /// <summary>
    /// �õ�λ��Ӧ���ص�Ѱ·�������
    /// </summary>
    private NavMeshAgent agent;
    [DisplayOnly]
    [Tooltip("�ƶ�Ŀ��ָʾ��")]
    private GameObject aimShowGO;

    /// <summary>
    /// �õ�λ��Ӧ���ص�Ѱ·�������
    /// </summary>
    public NavMeshAgent NavMeshAgent=> agent;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        movePathRender.enabled = false;
        unit.onSelected.AddListener(OnSelected);
        unit.onDeSelected.AddListener(OnDeSelected);
    }

    private void Update()
    {
        if(aimShowGO != null && unit.BeSelected) 
        {
            Vector3 nowPos = movePathRender.transform.position, aimPos = aimShowGO.transform.position;
            nowPos.y = aimPos.y = 0.1f;
            movePathRender.SetPosition(0, nowPos);
            movePathRender.SetPosition(1, aimPos);
        }
    }

    /// <summary>
    /// �̶�Ŀ����Կ�ʼ�ƶ�����
    /// </summary>
    /// <param name="aimPos">Ŀ���ƶ���</param>
    public void SetAimPos(Vector3 aimPos)
    {
        aimShowGO = Instantiate(UnitManager.Instance.aimMovePrefab, UnitManager.Instance.worldMoveRootT);
        aimPos.y += 0.05f;
        aimShowGO.transform.position = aimPos;
        aimShowGO.SetActive(unit.BeSelected);
        movePathRender.enabled = unit.BeSelected;
    }

    /// <summary>
    /// ��ѡ��ʱ����
    /// </summary>
    private void OnSelected()
    {
        if(aimShowGO != null)
        {
            aimShowGO.SetActive(true);
            movePathRender.enabled = true;
        }
    }

    /// <summary>
    /// ��ȡ��ѡ��ʱ����
    /// </summary>
    private void OnDeSelected()
    {
        if (aimShowGO != null)
        {
            aimShowGO.SetActive(false);
            movePathRender.enabled = false;
        }
    }
}

[TaskCategory("RTS")]
public class MoveTo : Action
{
    [Tooltip("�ƶ��ٶ�")]
    public SharedFloat speed = 10;
    [Tooltip("��ת�ٶ�")]
    public SharedFloat angularSpeed = 120;
    [Tooltip("��ɴﵽ������Ҫ�ﵽ�ģ���Ŀ�����С����")]
    public SharedFloat arriveDistance = 0.2f;
    [Tooltip("��ǰ����׷�ٵ�Ŀ��")]
    public SharedGameObject target;
    [Tooltip("��ǰ����׷�ٵ�Ŀ���λ��")]
    public SharedVector3 targetPosition;

    /// <summary>
    /// ������ƶ��������
    /// </summary>
    private Move move;
    /// <summary>
    /// Ѱ·����
    /// </summary>
    private NavMeshAgent navMeshAgent;

    /// <summary>
    /// ��ǰ��Ŀ���
    /// </summary>
    private Vector3 TargetPos { get => target.Value != null ? target.Value.transform.position : targetPosition.Value; }

    /// <summary>
    /// �жϴ����Ƿ�ﵽ��Ŀ��λ��
    /// </summary>
    /// <returns>���ص�ǰ�����Ƿ�ﵽ��Ŀ��λ��</returns>
    private bool HasArrived
    {
        get => (navMeshAgent.pathPending ? float.PositiveInfinity : navMeshAgent.remainingDistance) <= arriveDistance.Value;
    }


    /// <summary>
    /// �����µ�Ŀ���
    /// </summary>
    /// <param name="destination">����Ŀ���λ��</param>
    /// <returns>����Ѱ·�����Ƿ�Ŀ�����óɹ�</returns>
    private bool SetDestination(Vector3 destination)
    {
        navMeshAgent.isStopped = false;
        return navMeshAgent.SetDestination(destination);
    }

    /// <summary>
    /// ֹͣѰ·
    /// </summary>
    private void Stop()
    {
        if (navMeshAgent.hasPath) navMeshAgent.isStopped = true;
    }

    public override void OnAwake()
    {
        move = GetComponent<Move>();
        navMeshAgent = move.NavMeshAgent;
    }

    public override void OnStart()
    {
        navMeshAgent.speed = speed.Value;
        navMeshAgent.angularSpeed = angularSpeed.Value; 
        navMeshAgent.isStopped = false;

        if(SetDestination(TargetPos))move.SetAimPos(TargetPos) ;
    }

    /// <summary>
    /// �ﵽĿ��λ��ʱ������ɣ����������Ŀ��λ�ò���������
    /// </summary>
    /// <returns></returns>
    public override TaskStatus OnUpdate()
    {
        if (HasArrived) return TaskStatus.Success;
        SetDestination(TargetPos);
        return TaskStatus.Running;
    }

    /// <summary>
    /// �����жϽ���ʱֹͣѰ·
    /// </summary>
    public override void OnEnd() => Stop();

    /// <summary>
    /// �������ʱֹͣѰ·
    /// </summary>
    public override void OnBehaviorComplete() => Stop();
}