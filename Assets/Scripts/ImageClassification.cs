using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Barracuda;

public class ImageClassification : MonoBehaviour
{

    public NNModel modelAsset;
    public Texture2D texture;
    private Model m_RuntimeModel;
    private IWorker m_Worker;

    // Start is called before the first frame update
    void Start()
    {
        m_RuntimeModel = ModelLoader.Load(modelAsset);
        m_Worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Compute, m_RuntimeModel);

        Tensor input = new Tensor(texture);
        m_Worker.Execute(input);
        var output = m_Worker.PeekOutput();
        input.Dispose();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
