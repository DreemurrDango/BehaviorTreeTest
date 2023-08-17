using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Samples;

/// <summary>
/// 行走功能的实现模组，所有能够行动的单位都需要挂载该模块
/// </summary>
[RequireComponent(typeof(Unit))]
[RequireComponent(typeof(NavMeshAgent))]
public class Move : MonoBehaviour
{
    [SerializeField]
    [Tooltip("移动路径显示组件")]
    private LineRenderer movePathRender;

    [SerializeField,DisplayOnly]
    [Tooltip("移动目标形变")]
    private Transform targetT;
    [SerializeField, DisplayOnly]
    [Tooltip("移动目标位置")]
    private Vector3 targetPos;

    /// <summary>
    /// 该单位上的单位组件
    /// </summary>
    private Unit unit;
    /// <summary>
    /// 该单位上应挂载的寻路代理组件
    /// </summary>
    private NavMeshAgent agent;
    [DisplayOnly]
    [Tooltip("移动目标指示物")]
    private GameObject aimShowGO;

    /// <summary>
    /// 该单位上应挂载的寻路代理组件
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
    /// 固定目标点以开始移动任务
    /// </summary>
    /// <param name="aimPos">目标移动点</param>
    public void SetAimPos(Vector3 aimPos)
    {
        aimShowGO = Instantiate(UnitManager.Instance.aimMovePrefab, UnitManager.Instance.worldMoveRootT);
        aimPos.y += 0.05f;
        aimShowGO.transform.position = aimPos;
        aimShowGO.SetActive(unit.BeSelected);
        movePathRender.enabled = unit.BeSelected;
    }

    /// <summary>
    /// 被选中时动作
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
    /// 被取消选中时动作
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
    [Tooltip("移动速度")]
    public SharedFloat speed = 10;
    [Tooltip("旋转速度")]
    public SharedFloat angularSpeed = 120;
    [Tooltip("完成达到任务需要达到的，与目标的最小距离")]
    public SharedFloat arriveDistance = 0.2f;
    [Tooltip("当前正在追踪的目标")]
    public SharedGameObject target;
    [Tooltip("当前正在追踪的目标点位置")]
    public SharedVector3 targetPosition;

    /// <summary>
    /// 必须的移动功能组件
    /// </summary>
    private Move move;
    /// <summary>
    /// 寻路代理
    /// </summary>
    private NavMeshAgent navMeshAgent;

    /// <summary>
    /// 当前的目标点
    /// </summary>
    private Vector3 TargetPos { get => target.Value != null ? target.Value.transform.position : targetPosition.Value; }

    /// <summary>
    /// 判断代理是否达到了目标位置
    /// </summary>
    /// <returns>返回当前代理是否达到了目标位置</returns>
    private bool HasArrived
    {
        get => (navMeshAgent.pathPending ? float.PositiveInfinity : navMeshAgent.remainingDistance) <= arriveDistance.Value;
    }


    /// <summary>
    /// 设置新的目标点
    /// </summary>
    /// <param name="destination">设置目标点位置</param>
    /// <returns>返回寻路代理是否目标设置成功</returns>
    private bool SetDestination(Vector3 destination)
    {
        navMeshAgent.isStopped = false;
        return navMeshAgent.SetDestination(destination);
    }

    /// <summary>
    /// 停止寻路
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
    /// 达到目标位置时任务完成，否则则更新目标位置并持续运行
    /// </summary>
    /// <returns></returns>
    public override TaskStatus OnUpdate()
    {
        if (HasArrived) return TaskStatus.Success;
        SetDestination(TargetPos);
        return TaskStatus.Running;
    }

    /// <summary>
    /// 任务被中断结束时停止寻路
    /// </summary>
    public override void OnEnd() => Stop();

    /// <summary>
    /// 任务完成时停止寻路
    /// </summary>
    public override void OnBehaviorComplete() => Stop();
}